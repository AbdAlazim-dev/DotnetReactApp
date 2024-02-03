import "./app.css"
import Header from "./Header"
import HouseList from "../houseComponents/HouseList"
import HouseDetails from "../houseComponents/HouseDetails"
import { BrowserRouter, Route, Routes } from "react-router-dom"

function App() {
  return (
    <>
    <BrowserRouter>
      <div className="container">
          <Header subtitle={"Get the Best House Deal"}></Header>
        <Routes>
          <Route path="/" element={<HouseList />}/>
          <Route path="/house/:id" element={<HouseDetails />}/>
        </Routes> 
      </div>
    </BrowserRouter>
    </>
  )
}

export default App
