import { useState, useEffect } from "react";
import { Result } from "../models/ProductInterface";

const useProductTable = () => {
    const [result, setResult] = useState<Result | undefined>();
    const [pageNumber, setPageNumber] = useState(1);
    const [sortField, setSortField] = useState<string | null>("id");
    const [sortDirection, setSortDirection] = useState<"asc" | "desc">("asc");
    const [nameFilter, setNameFilter] = useState<string>("");
    const pageSize = 10;

    useEffect(() => {
        fetchResultByApi(pageNumber, pageSize, sortField, sortDirection, nameFilter);
    }, [pageNumber, sortField, sortDirection, nameFilter]);

    // Fetch products from API
    const fetchResultByApi = async (
        page: number,
        size: number,
        sortField: string | null,
        sortDirection: string,
        filter: string
    ) => {
        try {
            const url = new URL("product", window.location.origin);
            url.searchParams.append("pageNumber", page.toString());
            url.searchParams.append("pageSize", size.toString());
            if (sortField) {
                url.searchParams.append("sortBy", sortField);
                url.searchParams.append("sortOrder", sortDirection);
            }
            if (filter) {
                url.searchParams.append("nameFilter", filter);
            }

            const response = await fetch(url.toString());
            if (!response.ok) throw new Error("Error fetching data");
            const data = await response.json();
            setResult(data);
        } catch (error) {
            console.error("Failed to fetch data:", error);
        }
    };

    // Handle sorting based on column clicked
    const handleSort = (field: string) => {
        if (sortField === field) {
            setSortDirection(sortDirection === "asc" ? "desc" : "asc");
        } else {
            setSortField(field);
            setSortDirection("asc");
        }
    };

    // Handle next page
    const handleNextPage = () => {
        if (result && result.pageNumber < Math.ceil(result.totalCount / pageSize)) {
            setPageNumber(pageNumber + 1);
        }
    };

    // Handle previous page
    const handlePreviousPage = () => {
        if (pageNumber > 1) {
            setPageNumber(pageNumber - 1);
        }
    };

    // Handle name filter change
    const handleFilterChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setNameFilter(event.target.value);
    };

    return {
        result,
        pageNumber,
        sortField,
        sortDirection,
        nameFilter,
        handleSort,
        handleNextPage,
        handlePreviousPage,
        handleFilterChange,
    };
};

export default useProductTable;
