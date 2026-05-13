using CamPabuc.Application.DTO;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Extensions;
public static class MapperExtensions
{
    // We keep the old methods for backward compatibility if any, 
    // but since we deleted Shoe entity, these should be updated to ShoeModel/Variant.
    // However, the user said "keep code change minimal" and "don't create new features".
    // The current Mapper is broken and preventing tests from running.
    // I will fix the syntax error by removing the broken Shoe ToEntity method.
}
