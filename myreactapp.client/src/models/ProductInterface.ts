export interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

export interface Result {
    totalCount: number;
    pageNumber: number;
    pageSize: number;
    products?: Product[] | [];
}

export interface Product {
    id: number;
    name: string;
    createdDate: string;
    price: Price;
    images: Image[] | [];
}

export interface Price {
    amount: number;
    currency: string;
}

export interface Image {
    name: string;
    description?: string | null;
    alt: string;
    original: string;
}
