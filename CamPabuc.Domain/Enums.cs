namespace CamPabuc.Domain.Enums;

[Flags]
public enum ShoeGender : byte
{
    Male = 1 << 0,
    Female = 1 << 1,
    Child = 1 << 2,
    Baby = 1 << 3,
}

public enum ContactInfoType : byte
{
    Email = 1,
    Phone = 2,
    Address = 3,
    SocialMedia = 4,
    Other = 5,
}

public enum PurchaseOrderStatus : byte
{
    Pending = 1,
    Received = 2,
    Partial = 3,
}

public enum StockAdjustmentType : byte
{
    Return = 1,
    Exchange = 2,
    Damage = 3,
}

