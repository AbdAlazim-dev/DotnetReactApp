export type House = {
    id: number;
    address: string;
    country: string;
    description: string;
    price: number;
    photo: string;
};
export type HouseDetailsDto = {
    id: number;
    country: string;
    address: string;
    description: string;
    price: number;
    photo: string;
}
export type Error = {
    [name: string]: string[];
  };
  
export type Problem = {
type: string;
title: string;
status: number;
errors: Error;
};
  