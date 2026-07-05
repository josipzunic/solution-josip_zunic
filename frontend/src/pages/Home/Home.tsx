import styles from "./Home.module.css";
import { pageNames } from "../../constants/pageNames";
import { useEffect } from "react";
import { useFetch } from "../../hooks/useFetch";
import { productsUrl } from "../../api/products.api";
import type { Product } from "../../constants/types";

export const Home = () => {
  useEffect(() => {
    document.title = pageNames.home;
  }, []);

  const response = useFetch<Product[]>(productsUrl());
  const data = response.data;

  if (response.loading) return <div className={styles.home}>Loading…</div>;
  if (response.error)
    return <div className={styles.home}>Error: {response.error}</div>;
  if (!data || data.length === 0)
    return <div className={styles.home}>No products found</div>;

  return <div className={styles.home}>{data[0].name}</div>;
};
