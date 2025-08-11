namespace CamPabuc.Domain.Enums;

[Flags]
public enum ShoeGender : byte
{
    //Used flags to create sub categories easy
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

