import { Link, useParams } from "react-router-dom";
import { useDeleteHouse, useFetchHouseById } from "../hooks/HouseHooks";
import ApiStatus from "../types/ApiStatus";
import { currencyFormatter } from "../config";


const defaultPhoto = "https://cdn.pixabay.com/photo/2023/03/06/09/11/house-7833067_1280.png"
const HouseDetails = () => {
    const {id} = useParams();

    if(!id) {
        throw new Error("No house with this id ");
    }

    const houseId = parseInt(id)

    console.log(houseId);

    const {data, status, isSuccess} = useFetchHouseById(houseId);
    const deleteHouseMutation = useDeleteHouse();

    console.log(data?.country)


    if(!isSuccess) {
        return <ApiStatus status={status}/>
    }
    return (
    <div className="row">
        <div className="col-6">
            <div className="row">
                <img className="img-fluid" src={data.photo ? data.photo : defaultPhoto}/>
            </div>
            <div className="row mt-3">
          <div className="col-2">
            <Link
              className="btn btn-primary w-100"
              to={`/house/edit/${data.id}`}
            >
              Edit
            </Link>
          </div>
          <div className="col-2">
            <button
              className="btn btn-danger w-100"
              onClick={() => {
                if (window.confirm("Are you sure?"))
                  deleteHouseMutation.mutate(data);
              }}
            >
              Delete
            </button>
          </div>
        </div>
        </div>
        <div className="col-6">
            <div className="mb-2">
                <h5 className="col-12">{data.country}</h5>
            </div>
            <div className="row mb-2">
                <h3 className="col-12">{data.address}</h3>
            </div>
            <div className="row mb-2">
            <h2 className="themeFontColor col-12">
                {currencyFormatter.format(data.price)}
            </h2>
        </div>
        </div>
    </div>
    )
}

export default HouseDetails;