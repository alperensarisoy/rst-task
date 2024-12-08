import { Box, Button, Container, TextField, Typography } from "@mui/material";
import axios from "axios";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [formData, setFormData] = useState({
    username: "",
    password: "",
  });
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };
  const navigate = useNavigate();
  const handleLogin = async () => {
    try {
      const response = await axios.post(
        "https://localhost:44349/api/User/login",
        {
          userName: formData.username,
          password: formData.password,
        }
      );

      const token = response.data.token;

      console.log("Received token:", token); // Gelen token'ı kontrol edin
      sessionStorage.setItem("authToken", token); // Kaydedin

      navigate("/task");
      console.log("Login Successful:", response.data);
      alert("Login Successful!");
    } catch (error) {
      console.error("Login Failed:", error.response?.data || error.message);
      alert("Login Failed. Please check your credentials.");
    }
  };

  return (
    <Container maxWidth="sm">
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          mt: 8,
          boxShadow: 3,
          padding: 4,
          borderRadius: 2,
          bgcolor: "background.paper",
        }}
      >
        <Typography variant="h4" gutterBottom>
          Login
        </Typography>
        <TextField
          label="Username"
          name="username"
          value={formData.username}
          onChange={handleInputChange}
          fullWidth
          margin="normal"
          variant="outlined"
        />
        <TextField
          label="Password"
          name="password"
          type="password"
          value={formData.password}
          onChange={handleInputChange}
          fullWidth
          margin="normal"
          variant="outlined"
        />
        <Button
          variant="contained"
          color="primary"
          onClick={handleLogin}
          fullWidth
          sx={{ mt: 2 }}
        >
          Login
        </Button>
      </Box>
    </Container>
  );
};

export default Login;
