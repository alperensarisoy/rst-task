import React from "react";
import { Box, Typography, Button, Grid, Container } from "@mui/material";

const Home = () => {
  return (
    <Box>
      {/* Hero Section */}
      <Box
        sx={{
          bgcolor: "primary.main",
          color: "white",
          py: 10,
          textAlign: "center",
        }}
      >
        <Container maxWidth="sm">
          <Typography variant="h3" component="h1" gutterBottom>
            Welcome to Your Task Manager
          </Typography>
          <Typography variant="body1" sx={{ mb: 4 }}>
            Simplify your workflow and organize your tasks seamlessly with our
            intuitive platform.
          </Typography>
          <Button
            variant="contained"
            color="secondary"
            size="large"
            href="/tasks"
          >
            Start Now
          </Button>
        </Container>
      </Box>

      {/* Features Section */}
      <Container maxWidth="md" sx={{ py: 8 }}>
        <Typography variant="h4" component="h2" gutterBottom textAlign="center">
          Why Choose Us?
        </Typography>
        <Grid container spacing={4} sx={{ mt: 4 }}>
          <Grid item xs={12} sm={4}>
            <Box
              sx={{
                p: 4,
                borderRadius: 2,
                textAlign: "center",
                boxShadow: 3,
                bgcolor: "background.paper",
              }}
            >
              <Typography variant="h6" gutterBottom>
                Task Management
              </Typography>
              <Typography variant="body2">
                Organize your tasks with ease and stay productive.
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={4}>
            <Box
              sx={{
                p: 4,
                borderRadius: 2,
                textAlign: "center",
                boxShadow: 3,
                bgcolor: "background.paper",
              }}
            >
              <Typography variant="h6" gutterBottom>
                Insights
              </Typography>
              <Typography variant="body2">
                Track your progress and boost efficiency with smart analytics.
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={4}>
            <Box
              sx={{
                p: 4,
                borderRadius: 2,
                textAlign: "center",
                boxShadow: 3,
                bgcolor: "background.paper",
              }}
            >
              <Typography variant="h6" gutterBottom>
                Collaboration
              </Typography>
              <Typography variant="body2">
                Work seamlessly with your team and achieve goals faster.
              </Typography>
            </Box>
          </Grid>
        </Grid>
      </Container>

      {/* Call-to-Action Section */}
      <Box
        sx={{
          bgcolor: "secondary.main",
          color: "white",
          py: 8,
          textAlign: "center",
        }}
      >
        <Container maxWidth="sm">
          <Typography variant="h4" gutterBottom>
            Ready to Get Started?
          </Typography>
          <Typography variant="body1" sx={{ mb: 4 }}>
            Sign up now and take control of your tasks like never before.
          </Typography>
          <Button
            variant="contained"
            color="primary"
            size="large"
            href="/signup"
          >
            Sign Up
          </Button>
        </Container>
      </Box>
    </Box>
  );
};

export default Home;
