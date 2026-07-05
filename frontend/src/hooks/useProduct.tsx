import { useState } from "react";
import { productMapper } from "../api/mappers/products.mapper";
import { productsSearchUrl, productsUrl } from "../api/products.api";
import type { Product, ProductDto } from "../constants/types";
import { useFetch } from "./useFetch";

export const useProduct = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const url = searchTerm.trim() ? productsSearchUrl(searchTerm) : productsUrl();
  const { data, loading, error } = useFetch<ProductDto[]>(url);

  const products: Product[] | null = data ? data.map(productMapper) : null;

  return { products, loading, error, setSearchTerm };
};
