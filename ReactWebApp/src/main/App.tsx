import "./app.css"
import Header from "./Header"
import HouseList from "../houseComponents/HouseList"

function App() {
  return (
    <>
    <div className="container">
      <Header subtitle={"Get the Best House Deal"}></Header>
      <HouseList/>
    </div>
    </>
  )
}

export default App
