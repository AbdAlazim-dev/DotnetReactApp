export type House = {
    id: number;
    country: string;
    address: string;
    price: number;
};

export type HouseDetailsDto = {
    id: number;
    country: string;
    address: string;
    description: string;
    price: number;
    photo: string;
}