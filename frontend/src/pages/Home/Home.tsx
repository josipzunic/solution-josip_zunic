import styles from "./Home.module.css";
import { pageNames } from "../../constants/pageNames";
import { useEffect } from "react";
import { Loader } from "../../components/Loader/Loader";
import { ProductCard } from "../../components/ProductCard/ProductCard";
import { useProduct } from "../../hooks/useProduct";

export const Home = () => {
  useEffect(() => {
    document.title = pageNames.home;
  }, []);

  const { products, loading, error } = useProduct();

  if (loading)
    return (
      <div>
        <Loader />
      </div>
    );
  if (error) return <div> error </div>;
  if (!products || products.length === 0) return <div>empty</div>;

  return (
    <section>
      {products.map((product, idx) => (
        <ProductCard product={product} key={idx} />
      ))}
    </section>
  );
};
