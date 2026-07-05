export type Product = {
  imageUrl: string;
  name: string;
  price: number;
  description: string;
  id: number;
};

export type ProductDto = {
  imageUrl: string | null;
  description: string | null;
  name: string;
  price: number;
  id: number;
};
