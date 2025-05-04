import { DataTable } from "@/components/data-table";
import { Skeleton } from "@/components/ui/skeleton";
import { useEffect, useState } from "react";
import { fetchPageData } from "@/lib/data-fetch";
const ManufacturerList = () => {
  const [pageData, setPageData] = useState();
  useEffect(() => {
    const getData = async () => {
      var data = await fetchPageData("manufacturers");
      setPageData(data);
    };
    getData();
  }, []);
  return !pageData ? (
    <Skeleton>Loading</Skeleton>
  ) : (
    <DataTable data={pageData} />
  );
};
export default ManufacturerList;
