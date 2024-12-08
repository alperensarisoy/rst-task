import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import "./App.css";
import Home from "./Pages/Home/Home";
import Navbar from "./Component/Navbar/Navbar";
import Footer from "./Component/Footer/Footer";
import { Box } from "@mui/material";
import Task from "./Pages/Task/Task";
import Login from "./Pages/Login/Login";
import About from "./Pages/About/About";

function App() {
  return (
    <Router>
      <Box
        sx={{ minHeight: "100vh", display: "flex", flexDirection: "column" }}
      >
        <Navbar />
        <Box sx={{ flexGrow: 1 }}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/task" element={<Task />} />
            <Route path="/login" element={<Login />} />
            <Route path="/about" element={<About />} />
          </Routes>
        </Box>
        <Footer />
      </Box>
    </Router>
  );
}

export default App;
