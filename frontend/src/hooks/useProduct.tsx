import { productMapper } from "../api/mappers/products.mapper";
import { productsUrl } from "../api/products.api";
import type { Product, ProductDto } from "../constants/types";
import { useFetch } from "./useFetch";

export const useProduct = () => {
  const { data, loading, error } = useFetch<ProductDto[]>(productsUrl());

  const products: Product[] | null = data ? data.map(productMapper) : null;

  return { products, loading, error };
};
