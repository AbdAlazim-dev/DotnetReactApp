import { House, HouseDetailsDto, Problem } from "./../types/house";
import Config from "../config";
import { useMutation, useQuery, useQueryClient } from "react-query";
import axios, { AxiosError, AxiosResponse } from "axios";
import { useNavigate } from "react-router-dom";

const useFetchHouses = () => {
  return useQuery<House[], AxiosError>("houses", () => 
    axios.get(`${Config.baseUrl}/houses`).then((res) => res.data)
  );
};

const useAddHouse = () => {
  const nav = useNavigate()
  const queryClient = useQueryClient()
  return useMutation<AxiosResponse, AxiosError<Problem>, House>(
    (house) => axios.post(`${Config.baseUrl}/houses/`, house),
      {
        onSuccess: () => {
          queryClient.invalidateQueries("houses");
          nav("/");
        }
      }

  )
}
const useUpdateHouse = () => {
  const nav = useNavigate()
  const queryClient = useQueryClient()
  return useMutation<AxiosResponse, AxiosError<Problem>, House>(
    (house) => axios.put(`${Config.baseUrl}houses/`, house),
      {
        onSuccess: (_,house) => {
          queryClient.invalidateQueries("houses");
          nav(`houses/${house.id}`);
        }
      }

  )
}
const useDeleteHouse = () => {
  const queryClient = useQueryClient();
  const nav = useNavigate();
  return useMutation<AxiosResponse, AxiosError, House>(
    (h) => axios.delete(`${Config.baseUrl}/houses/${h.id}`),
    {
      onSuccess: () => {
        queryClient.invalidateQueries("houses");
        nav("/");
      },
    }
  );
};
const useFetchHouseById = (Id: number) => {
  return useQuery<HouseDetailsDto, AxiosError>(["houses", Id], () =>
  axios.get(`${Config.baseUrl}/houses/${Id}`).then((res) => res.data));
}

export{ useFetchHouses,
        useFetchHouseById,
        useAddHouse,
        useUpdateHouse,
        useDeleteHouse };