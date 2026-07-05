import styles from "./Home.module.css";
import { pageNames } from "../../constants/pageNames";
import { useEffect } from "react";
import { Loader } from "../../components/Loader/Loader";
import { ProductCard } from "../../components/ProductCard/ProductCard";
import { useProduct } from "../../hooks/useProduct";
import { Filters } from "../../components/Filters/Filters";

export const Home = () => {
  useEffect(() => {
    document.title = pageNames.home;
  }, []);

  const { products, loading, error, setSearchTerm } = useProduct();
  const handleSearch = (searchTerm: string) => {
    setSearchTerm(searchTerm);
  };

  if (loading)
    return (
      <div>
        <Loader />
      </div>
    );
  if (error) return <div> error </div>;
  if (!products) return <div>empty</div>;

  return (
    <section className={styles.home}>
      <Filters onSearch={handleSearch} />
      {products.map((product, idx) => (
        <ProductCard product={product} key={idx} />
      ))}
    </section>
  );
};
