import { buildUrl } from "./client";

export const productsUrl = (id?: string) =>
  buildUrl(!id ? "Products" : `Products/${id}`);
