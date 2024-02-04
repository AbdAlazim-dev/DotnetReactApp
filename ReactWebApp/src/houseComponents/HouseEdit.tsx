import { useParams } from "react-router-dom"
import HouseForm from "./HouseForm"
import { useFetchHouseById, useUpdateHouse } from "../hooks/HouseHooks";
import ApiStatus from "../types/ApiStatus";


const HouseEdit =  () => {
    const { id } = useParams();

    if(id == null) throw new Error(`no house with the id ${id}`);
    const houseId = parseInt(id);
    const {status, data, isSuccess} = useFetchHouseById(houseId);

    const updateHouse = useUpdateHouse()

    if(!isSuccess) return <ApiStatus status={status} />

    return <HouseForm house={data} submitted={(h) => updateHouse.mutate(h)}/>
}

export default HouseEdit;