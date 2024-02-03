
import {useFetchHouses, useFetchHouseById} from "../hooks/HouseHooks";
import { currencyFormatter } from "../config";
import ApiStatus from "../types/ApiStatus";

const HouseList = () => {
    const {data, status, isSuccess} = useFetchHouses();
    let content;

    if (!isSuccess) {
        return <ApiStatus status={status} />
    }

    return (
        <div>
            <div className="row mb-2">
                <h5 className="themeFontColor text-center"></h5>
            </div>
            <table className="table table-hover">
                <thead>
                    <tr>
                        <th>Address</th>
                        <th>Country</th>
                        <th>Asking Price</th>
                    </tr>
                </thead>
                <tbody>
                    {data && data.map((house) => 
                        <tr key={house.id}>
                            <td>{house.address}</td>
                            <td>{house.country}</td>
                            <td>{currencyFormatter.format(house.price)}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    )
}

export default HouseList;