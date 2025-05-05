import { DataTable } from "@/components/data-table";
import { useEffect, useState } from "react";
import { fetchPageData } from "@/lib/data-fetch";
const ManufacturerList = () => {
  const [pageData, setPageData] = useState<any>();
  useEffect(() => {
    const getData = async () => {
      var data = await fetchPageData("manufacturers");
      console.log(data);
      setPageData(data);
    };
    getData();
  }, []);
  return !pageData ? (
    <span>Loading</span>
  ) : (
    <DataTable data={pageData.products} />
  );
};
export default ManufacturerList;
