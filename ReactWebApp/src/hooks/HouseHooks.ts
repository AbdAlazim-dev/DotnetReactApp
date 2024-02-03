import { House, HouseDetailsDto } from "./../types/house";
import Config from "../config";
import { useQuery } from "react-query";
import axios, { AxiosError } from "axios";

const useFetchHouses = () => {
  return useQuery<House[], AxiosError>("houses", () => 
    axios.get(`${Config.baseUrl}/houses`).then((res) => res.data)
  );
};

const useFetchHouseById = (Id: number) => {
  return useQuery<HouseDetailsDto, AxiosError>(["houses", Id], () =>
  axios.get(`${Config.baseUrl}/houses/${Id}`).then((res) => res.data));
}

export{ useFetchHouses, useFetchHouseById };