using System.Collections;
using System.Linq.Expressions;
using System.Text;
using Dapper;

public class SqlFilterResult
{
    public string Sql { get; set; }
    public DynamicParameters Parameters { get; set; }

    public SqlFilterResult(string sql, DynamicParameters parameters)
    {
        Sql = sql;
        Parameters = parameters;
    }
}

public static class SqlPredicateBuilder
{
    public static SqlFilterResult ToSqlFilter<T>(Expression<Func<T, bool>> predicate)
    {
        var visitor = new ParameterizedSqlVisitor();
        return visitor.Translate(predicate.Body);
    }

    private class ParameterizedSqlVisitor : ExpressionVisitor
    {
        private readonly StringBuilder _sb = new();
        private readonly DynamicParameters _parameters = new();
        private int _paramIndex = 0;

        public SqlFilterResult Translate(Expression expression)
        {
            Visit(expression);
            return new SqlFilterResult(_sb.ToString(), _parameters);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            _sb.Append("(");
            Visit(node.Left);
            _sb.Append(" ").Append(GetSqlOperator(node.NodeType)).Append(" ");
            Visit(node.Right);
            _sb.Append(")");
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Not)
            {
                _sb.Append("NOT ");
                Visit(node.Operand);
                return node;
            }

            return base.VisitUnary(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression is ConstantExpression constant)
            {
                var container = constant.Value;
                var value = node.Member.DeclaringType?
                    .GetField(node.Member.Name)?
                    .GetValue(container);

                string paramName = AddParameter(value);
                _sb.Append(paramName);
                return node;
            }

            if (node.Expression != null && node.Expression.NodeType == ExpressionType.MemberAccess)
            {
                Visit(node.Expression);
                _sb.Append(".").Append(node.Member.Name);
                return node;
            }

            _sb.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            string paramName = AddParameter(node.Value);
            _sb.Append(paramName);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(string))
            {
                Visit(node.Object);
                _sb.Append(" LIKE ");

                var arg = (ConstantExpression)node.Arguments[0];
                var argValue = arg.Value?.ToString();

                string pattern = node.Method.Name switch
                {
                    "StartsWith" => $"{argValue}%",
                    "EndsWith" => $"%{argValue}",
                    "Contains" => $"%{argValue}%",
                    _ => throw new NotSupportedException($"Method {node.Method.Name} not supported")
                };

                string paramName = AddParameter(pattern);
                _sb.Append(paramName);
                return node;
            }

            if (node.Method.Name == "Contains")
            {
                Expression fieldExpr = null;
                IEnumerable collection = null;

                if (node.Object != null)
                {
                    collection = (IEnumerable)GetValue(node.Object);
                    fieldExpr = node.Arguments[0];
                }
                else if (node.Arguments.Count == 2)
                {
                    collection = (IEnumerable)GetValue(node.Arguments[0]);
                    fieldExpr = node.Arguments[1];
                }

                Visit(fieldExpr);
                _sb.Append(" IN ");
                string paramName = AddParameter(collection);
                _sb.Append(paramName);
                return node;
            }

            throw new NotSupportedException($"Unsupported method: {node.Method.Name}");
        }

        private string AddParameter(object value)
        {
            string name = $"@param{_paramIndex++}";
            _parameters.Add(name, value);
            return name;
        }

        private object GetValue(Expression expr)
        {
            var lambda = Expression.Lambda(expr);
            var compiled = lambda.Compile();
            return compiled.DynamicInvoke();
        }

        private string GetSqlOperator(ExpressionType type) => type switch
        {
            ExpressionType.AndAlso => "AND",
            ExpressionType.OrElse => "OR",
            ExpressionType.Equal => "=",
            ExpressionType.NotEqual => "!=",
            ExpressionType.LessThan => "<",
            ExpressionType.LessThanOrEqual => "<=",
            ExpressionType.GreaterThan => ">",
            ExpressionType.GreaterThanOrEqual => ">=",
            _ => throw new NotSupportedException($"Unsupported binary operator: {type}")
        };
    }
}

