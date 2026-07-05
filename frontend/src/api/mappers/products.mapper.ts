import { defaultImageUrl } from "../../constants/defaultImageUrl";
import type { Product, ProductDto } from "../../constants/types";

export const productMapper = (dto: ProductDto): Product => {
  const product: Product = {
    imageUrl: dto.imageUrl ?? defaultImageUrl,
    description: dto.description ?? "",
    price: dto.price,
    name: dto.name,
  };

  return product;
};
