import React, { useEffect, useState } from "react";
import {
  Box,
  Button,
  Grid,
  Typography,
  TextField,
  Modal,
  IconButton,
} from "@mui/material";
import axios from "axios";
import { Edit, Delete } from "@mui/icons-material";

const Task = () => {
  const [tasks, setTasks] = useState([]);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [selectedTask, setSelectedTask] = useState(null);
  const [formData, setFormData] = useState({ title: "", description: "" });

  // Fetch all tasks
  const fetchTasks = async () => {
    try {
      const authToken = sessionStorage.getItem("authToken");
      if (!authToken) {
        console.error("No token found");
        window.location.href = "/login";
        return;
      }
      const response = await axios.get(
        "https://localhost:44349/api/Task/GetAll",
        {
          headers: { Authorization: `Bearer ${authToken}` },
        }
      );
      setTasks(response.data);
    } catch (error) {
      console.error("Error fetching tasks:", error);
    }
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  // Handle form input changes
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  // Add a new task
  const handleAddTask = async () => {
    try {
      const authToken = sessionStorage.getItem("authToken");
      await axios.post(
        "https://localhost:44349/api/Task/AddTask",
        { title: formData.title, description: formData.description },
        { headers: { Authorization: `Bearer ${authToken}` } }
      );
      setIsAddModalOpen(false);
      fetchTasks(); // Refresh tasks
    } catch (error) {
      console.error("Error adding task:", error);
    }
  };

  // Delete a task
  const handleDeleteTask = async (task) => {
    try {
      const authToken = sessionStorage.getItem("authToken");
      if (!authToken) {
        console.error("No token found");
        window.location.href = "/login";
        return;
      }
      await axios.delete("https://localhost:44349/api/Task/DeleteTask", {
        headers: {
          Authorization: `Bearer ${authToken}`,
        },
        data: {
          id: task.id,
          createdAt: task.createdAt,
          title: task.title,
          description: task.description,
        },
      });
      fetchTasks(); // Refresh tasks
    } catch (error) {
      console.error(
        "Error deleting task:",
        error.response?.data || error.message
      );
    }
  };

  // Open edit modal
  const openEditModal = (task) => {
    setSelectedTask(task);
    setFormData({ title: task.title, description: task.description });
    setIsEditModalOpen(true);
  };

  // Update a task
  const handleUpdateTask = async () => {
    try {
      const authToken = sessionStorage.getItem("authToken");
      if (!authToken) {
        console.error("No token found");
        window.location.href = "/login";
        return;
      }
      await axios.put(
        "https://localhost:44349/api/Task/UpdateTask",
        {
          id: selectedTask.id,
          title: formData.title,
          description: formData.description,
        },
        {
          headers: {
            Authorization: `Bearer ${authToken}`,
          },
        }
      );
      setIsEditModalOpen(false);
      fetchTasks(); // Refresh tasks
    } catch (error) {
      console.error(
        "Error updating task:",
        error.response?.data || error.message
      );
    }
  };

  return (
    <Box p={3}>
      <Typography variant="h4" gutterBottom>
        Task Management
      </Typography>
      <Button
        variant="contained"
        color="primary"
        onClick={() => setIsAddModalOpen(true)}
        sx={{ mb: 2 }}
      >
        Add Task
      </Button>

      {/* Task Grid */}
      <Grid container spacing={2}>
        {tasks.map((task) => (
          <Grid item xs={12} sm={6} md={4} key={task.id}>
            <Box
              sx={{
                border: "1px solid #ddd",
                borderRadius: "8px",
                p: 2,
                bgcolor: "#f9f9f9",
              }}
            >
              <Typography variant="h6">{task.title}</Typography>
              <Typography variant="body2">{task.description}</Typography>
              <Typography variant="caption">
                {new Date(task.createdAt).toLocaleDateString()}
              </Typography>
              <Box mt={2} sx={{ display: "flex", gap: 1 }}>
                <IconButton color="primary" onClick={() => openEditModal(task)}>
                  <Edit />
                </IconButton>
                <IconButton
                  color="error"
                  onClick={() => handleDeleteTask(task)}
                >
                  <Delete />
                </IconButton>
              </Box>
            </Box>
          </Grid>
        ))}
      </Grid>

      {/* Add Task Modal */}
      <Modal open={isAddModalOpen} onClose={() => setIsAddModalOpen(false)}>
        <Box
          sx={{
            position: "absolute",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
            bgcolor: "white",
            p: 4,
            borderRadius: 2,
            boxShadow: 24,
            width: 400,
          }}
        >
          <Typography variant="h6" mb={2}>
            Add New Task
          </Typography>
          <TextField
            label="Title"
            name="title"
            fullWidth
            margin="normal"
            value={formData.title}
            onChange={handleInputChange}
          />
          <TextField
            label="Description"
            name="description"
            fullWidth
            margin="normal"
            value={formData.description}
            onChange={handleInputChange}
          />
          <Button
            variant="contained"
            color="primary"
            fullWidth
            sx={{ mt: 2 }}
            onClick={handleAddTask}
          >
            Add Task
          </Button>
        </Box>
      </Modal>

      {/* Edit Task Modal */}
      <Modal open={isEditModalOpen} onClose={() => setIsEditModalOpen(false)}>
        <Box
          sx={{
            position: "absolute",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
            bgcolor: "white",
            p: 4,
            borderRadius: 2,
            boxShadow: 24,
            width: 400,
          }}
        >
          <Typography variant="h6" mb={2}>
            Edit Task
          </Typography>
          <TextField
            label="Title"
            name="title"
            fullWidth
            margin="normal"
            value={formData.title}
            onChange={handleInputChange}
          />
          <TextField
            label="Description"
            name="description"
            fullWidth
            margin="normal"
            value={formData.description}
            onChange={handleInputChange}
          />
          <Button
            variant="contained"
            color="primary"
            fullWidth
            sx={{ mt: 2 }}
            onClick={handleUpdateTask}
          >
            Update Task
          </Button>
        </Box>
      </Modal>
    </Box>
  );
};

export default Task;
