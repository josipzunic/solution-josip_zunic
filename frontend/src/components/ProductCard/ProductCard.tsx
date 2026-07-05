import type { Product } from "../../constants/types";
import styles from "./ProductCard.module.css"

type Props = {
  product: Product;
};

export const ProductCard = ({ product }: Props) => {
  return (
    <div className={styles.card}>
      <img src={product.imageUrl} className={styles.img}/>
      <h3 className={styles.name}>{product.name}</h3>
      <h2 className={styles.price}>{product.price} €</h2>
      <p className={styles.description}>{product.description}</p>
      <button className={styles.btn}>Like</button>
    </div>
  );
};
