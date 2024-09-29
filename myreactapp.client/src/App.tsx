import { useEffect, useState } from "react";
import "./App.css";

interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface Result {
    totalCount: number;
    pageNumber: number;
    pageSize: number;
    items?: Product[] | [];
}

interface Product {
    id: number;
    name: string;
    createdDate: string;
    price: Price;
    images: Image[] | [];
}

interface Price {
    amount: number;
    currency: string;
}

interface Image {
    name: string;
    description?: string | null;
    alt: string;
    original: string;
}

function App() {
    const [forecasts, setForecasts] = useState<Forecast[]>();
    const [result, setResult] = useState<Result>();

    useEffect(() => {
        populateWeatherData();
        fetchResultByApi();
    }, []);

    console.log(result);

    const contents =
        result === undefined ? (
            <p>
                <em>
                    Loading... Please refresh once the ASP.NET backend has started. See{" "}
                    <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more
                    details.
                </em>
            </p>
        ) : (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th></th>
                        <th>Name</th>
                        <th>Created date</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {result.items?.map((product) => (
                        <tr key={product.id}>
                            <td>
                                <img
                                    src={product.images[0].original}
                                    alt={product.images[0].alt}
                                    width="50" // Adjust width and height as per your need
                                    height="50"
                                />
                            </td>
                            <td>{product.name}</td>
                            <td>{product.createdDate}</td>
                            <td>
                                {product.price.amount} {product.price.currency}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );

    return (
        <div>
            <h1 id="tableLabel">PRODUCT TABLE</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateWeatherData() {
        const response = await fetch("weatherforecast");
        const data = await response.json();
        setForecasts(data);
    }

    async function fetchResultByApi() {
        const response = await fetch("product");
        const data = await response.json();
        setResult(data);
    }
}

export default App;
