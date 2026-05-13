export interface ShoeModel {
    id: number;
    name: string;
    brand: string;
    baseMaterial: string;
    description?: string;
    manufacturerId: number;
    shoeCategoryId: number;
}

export interface ShoeVariant {
    id: number;
    shoeModelId: number;
    skuCode: string;
    size: string;
    color: string;
    costPrice: number;
    retailPrice: number;
    stockQuantity: number;
}
