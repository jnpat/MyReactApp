import useProductTable from "../hooks/useProductTable";
import { convertIsoToDate, formatDateToReadableString } from "../utils/date-convertion";

const ProductTable = () => {
    const {
        result,
        pageNumber,
        sortField,
        sortDirection,
        nameFilter,
        handleSort,
        handleNextPage,
        handlePreviousPage,
        handleFilterChange,
    } = useProductTable();

    if (!result) {
        return (
            <p>
                <em>Loading...</em>
            </p>
        );
    }

    return (
        <div className="product-component">
            {/* Search by name Controls */}
            <div className="search-by-name-control">
                <input
                    type="text"
                    placeholder="Filter by name"
                    value={nameFilter}
                    onChange={handleFilterChange}
                    style={{ marginBottom: "10px" }}
                />
            </div>

            {/* Sort Controls */}
            <div className="sort-controls">
                <button onClick={() => handleSort("name")}>Sort name</button>
                <button onClick={() => handleSort("createdDate")}>Sort date</button>
            </div>

            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th></th>
                        <th onClick={() => handleSort("name")}>
                            Name {sortField === "name" && (sortDirection === "asc" ? "↑" : "↓")}
                        </th>
                        <th onClick={() => handleSort("createdDate")}>
                            Created date {sortField === "createdDate" && (sortDirection === "asc" ? "↑" : "↓")}
                        </th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {result.products?.map((product) => (
                        <tr key={product.id}>
                            <td>
                                <img
                                    src={`https://tabledusud.nl${product.images[0]?.original}`}
                                    alt={product.images[0]?.alt}
                                    width="100"
                                    height="100"
                                />
                            </td>
                            <td>{product.name}</td>
                            <td>{formatDateToReadableString(convertIsoToDate(product.createdDate))}</td>
                            <td>
                                {product.price.amount} {product.price.currency}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {/* Pagination Controls */}
            <div className="pagination-controls">
                <button onClick={handlePreviousPage} disabled={pageNumber === 1}>
                    Previous
                </button>
                <span>
                    Page {result.pageNumber} of {Math.ceil(result.totalCount / 10)}
                </span>
                <button onClick={handleNextPage} disabled={result.pageNumber >= Math.ceil(result.totalCount / 10)}>
                    Next
                </button>
            </div>
        </div>
    );
};

export default ProductTable;
