import { House } from "./../types/house";
import Config from "../config";
import { useEffect, useState } from "react";

const useFetchHouses = (): House[] => {
  const [allHouses, setAllHouses] = useState<House[]>([]);

  useEffect(() => {
    const fetchHouses = async () => {
      const rsp = await fetch(`${Config.baseUrl}/houses`);
      const houses = await rsp.json();
      setAllHouses(houses);
    };
    fetchHouses();
  }, []);

  return allHouses;
};

export default useFetchHouses;