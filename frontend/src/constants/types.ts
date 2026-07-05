export type Product = {
  imageUrl: string;
  name: string;
  price: number;
  description: string;
};

export type ProductDto = {
  imageUrl: string | null;
  description: string | null;
  name: string;
  price: number;
};
