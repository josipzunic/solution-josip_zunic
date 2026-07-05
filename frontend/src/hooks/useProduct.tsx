import { productMapper } from "../api/mappers/products.mapper";
import type { Product, ProductDto } from "../constants/types";
import { useFetch } from "./useFetch";

export const useProduct = (url: string) => {
  const { data, loading, error } = useFetch<ProductDto[]>(url);

  const normalized = Array.isArray(data) ? data : data ? [data] : [];

  const products: Product[] = normalized.map(productMapper);

  return { products, loading, error };
};
