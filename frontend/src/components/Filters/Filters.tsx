import { useRef, useState } from "react";
import { useTheme } from "../../hooks/useTheme";
import styles from "./Filters.module.css";

export const Filters = () => {
  const searchRef = useRef<HTMLInputElement>(null);
  const { lightMode } = useTheme();

  const [priceRange, setPriceRange] = useState<[number, number]>([100, 800]);
  const [status, setStatus] = useState("all");

  const handleMinChange = (value: string) => {
  setPriceRange((prev) => [Number(value), prev[1]]);
};

const handleMaxChange = (value: string) => {
  setPriceRange((prev) => [prev[0], Number(value)]);
};

  const normalizeRange = () => {
    setPriceRange(([min, max]) => {
      if (min > max) return [max, min];
      return [min, max];
    });
  };

  return (
    <form className={styles.filters} onSubmit={(e) => e.preventDefault()}>
      <input
        ref={searchRef}
        type="search"
        className={`${styles.input} ${
          lightMode ? styles.inputLight : styles.inputDark
        }`}
        placeholder="Search launches..."
      />

      <select
        value={status}
        onChange={(e) => setStatus(e.target.value)}
        className={`${styles.select} ${
          lightMode ? styles.inputLight : styles.inputDark
        }`}
      >
        <option value="all">No filter</option>
        <option value="false">Failed missions</option>
        <option value="true">Successful missions</option>
      </select>

      <div className={styles.priceWrapper}>
        <label className={styles.priceLabel}>
          Price: ${priceRange[0]} - ${priceRange[1]}
        </label>

        <div className={styles.priceInputs}>
          <input
            type="number"
            value={priceRange[0]}
            onChange={(e) => handleMinChange(e.target.value)}
            onBlur={normalizeRange}
            className={`${styles.input} ${
              lightMode ? styles.inputLight : styles.inputDark
            }`}
            placeholder="Min"
          />

          <span className={styles.dash}>—</span>

          <input
            type="number"
            value={priceRange[1]}
            onChange={(e) => handleMaxChange(e.target.value)}
            onBlur={normalizeRange}
            className={`${styles.input} ${
              lightMode ? styles.inputLight : styles.inputDark
            }`}
            placeholder="Max"
          />
        </div>
      </div>

      <button type="submit" className={`${styles.button} ${
              lightMode ? styles.buttonLight : styles.buttonDark
            }`}>
        Apply
      </button>
    </form>
  );
};