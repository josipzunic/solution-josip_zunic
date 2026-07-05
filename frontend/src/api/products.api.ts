import { buildUrl } from "./client";

export const productsUrl = (id?: string) =>
  buildUrl(!id ? "Products" : `Products/${id}`);

export const productsSearchUrl = (name: string) =>
  buildUrl(`Products/search?name=${encodeURIComponent(name)}`);

export const productsCategoriesUrl = () => buildUrl("Products/categories");
