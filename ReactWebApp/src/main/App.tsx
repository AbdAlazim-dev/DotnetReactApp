import "./app.css"
import Header from "./Header"
import HouseList from "../houseComponents/HouseList"
import HouseDetails from "../houseComponents/HouseDetails"
import { BrowserRouter, Route, Routes } from "react-router-dom"
import HouseAdd from "../houseComponents/HouseAdd"
import HouseEdit from "../houseComponents/HouseEdit"

function App() {
  return (
    <>
    <BrowserRouter>
      <div className="container">
          <Header subtitle={"Get the Best House Deal"}></Header>
        <Routes>
          <Route path="/" element={<HouseList />}/>
          <Route path="/house/:id" element={<HouseDetails />}/>
          <Route path="/house/add" element={<HouseAdd />}/>
          <Route path="/house/edit/:id" element={<HouseEdit />}/>
        </Routes> 
      </div>
    </BrowserRouter>
    </>
  )
}

export default App
