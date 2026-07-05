import { productsCategoriesUrl } from "../api/products.api";
import { useFetch } from "./useFetch";

export const useCategories = () => {
  const { data, loading, error } = useFetch<string[]>(productsCategoriesUrl());
  return { categories: data ?? [], loading, error };
};