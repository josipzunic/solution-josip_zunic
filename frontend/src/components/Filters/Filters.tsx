import { useRef, useState } from "react";
import { useTheme } from "../../hooks/useTheme";
import styles from "./Filters.module.css";

export const Filters = () => {
  const searchRef = useRef<HTMLInputElement>(null);
  const { lightMode } = useTheme();
  const [price, setPrice] = useState(500);

  return (
  <form className={styles.filters} onSubmit={(e) => e.preventDefault()}>
    <input
      ref={searchRef}
      type="search"
      className={lightMode ? styles.inputLight : styles.inputDark}
      placeholder="Search launches..."
    />

    <select className={lightMode ? styles.selectLight : styles.selectDark}>
      <option value="all">No filter</option>
      <option value="false">Failed missions</option>
      <option value="true">Successful missions</option>
    </select>

    <div className={styles.priceWrapper}>
      <label className={styles.priceLabel}>Max price: {price}</label>
      <input
        type="range"
        min={0}
        max={1000}
        value={price}
        onChange={(e) => setPrice(Number(e.target.value))}
        className={styles.slider}
      />
    </div>

    <button type="submit" className={styles.button}>
      Apply
    </button>
  </form>
);
};
