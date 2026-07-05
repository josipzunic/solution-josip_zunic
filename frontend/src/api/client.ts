export const apiUrl = import.meta.env.VITE_API_URL;
export const buildUrl = (path: string) => `${apiUrl}${path}`;
