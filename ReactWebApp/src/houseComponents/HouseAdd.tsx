import ValidationSummary from "../ValidationSummary";
import { useAddHouse } from "../hooks/HouseHooks"
import { House } from "../types/house";
import HouseForm from "./HouseForm";


const HouseAdd = () => {
    const addHouseMutiation = useAddHouse();

    const house: House = {
        address : "",
        country : "",
        price : 0,
        description : "",
        id : 0,
        photo : "",
    }

    return <>
          {addHouseMutiation.isError && (
        <ValidationSummary error={addHouseMutiation.error} />
      )}
    <HouseForm house={house} submitted={(house) => addHouseMutiation.mutate(house)} />
</>
}

export default HouseAdd;