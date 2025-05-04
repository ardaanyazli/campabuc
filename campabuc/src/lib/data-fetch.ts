// const API_BASE = "https://localhost";
const API_BASE = "https://dummyjson.com/products";
const fetchPageData = async (source: string) => {
  // const response = await fetch(`${API_BASE}/${source}`);
  const response = await fetch(API_BASE);
  const fetchedData = await response.json();
  return fetchedData;
};

export { fetchPageData };
