import React from "react";
import { Box, Container, Typography, Grid, Paper } from "@mui/material";

const About = () => {
  return (
    <Box sx={{ bgcolor: "background.default", py: 8 }}>
      <Container maxWidth="md">
        {/* Header Section */}
        <Typography variant="h4" component="h1" gutterBottom textAlign="center">
          About Us
        </Typography>
        <Typography variant="body1" sx={{ textAlign: "center", mb: 4 }}>
          Learn more about our mission, vision, and the team behind this
          project.
        </Typography>

        {/* Mission and Vision Section */}
        <Grid container spacing={4}>
          <Grid item xs={12} sm={6}>
            <Paper
              elevation={3}
              sx={{ p: 4, borderRadius: 2, textAlign: "center" }}
            >
              <Typography variant="h6" gutterBottom>
                Our Mission
              </Typography>
              <Typography variant="body2">
                To empower individuals and teams by providing intuitive task
                management solutions that drive productivity and success.
              </Typography>
            </Paper>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Paper
              elevation={3}
              sx={{ p: 4, borderRadius: 2, textAlign: "center" }}
            >
              <Typography variant="h6" gutterBottom>
                Our Vision
              </Typography>
              <Typography variant="body2">
                To be the go-to platform for task organization and team
                collaboration across the globe.
              </Typography>
            </Paper>
          </Grid>
        </Grid>

        {/* Team Section */}
        <Box sx={{ mt: 8 }}>
          <Typography
            variant="h5"
            component="h2"
            gutterBottom
            textAlign="center"
          >
            Meet Our Team
          </Typography>
          <Typography variant="body2" textAlign="center" sx={{ mb: 4 }}>
            Our talented and dedicated team is committed to helping you achieve
            your goals.
          </Typography>
          <Grid container spacing={4}>
            <Grid item xs={12} sm={4}>
              <Paper
                elevation={3}
                sx={{
                  p: 4,
                  textAlign: "center",
                  borderRadius: 2,
                }}
              >
                <Typography variant="h6" gutterBottom>
                  John Doe
                </Typography>
                <Typography variant="body2">Founder & CEO</Typography>
              </Paper>
            </Grid>
            <Grid item xs={12} sm={4}>
              <Paper
                elevation={3}
                sx={{
                  p: 4,
                  textAlign: "center",
                  borderRadius: 2,
                }}
              >
                <Typography variant="h6" gutterBottom>
                  Jane Smith
                </Typography>
                <Typography variant="body2">Head of Product</Typography>
              </Paper>
            </Grid>
            <Grid item xs={12} sm={4}>
              <Paper
                elevation={3}
                sx={{
                  p: 4,
                  textAlign: "center",
                  borderRadius: 2,
                }}
              >
                <Typography variant="h6" gutterBottom>
                  Alice Brown
                </Typography>
                <Typography variant="body2">Lead Developer</Typography>
              </Paper>
            </Grid>
          </Grid>
        </Box>
      </Container>
    </Box>
  );
};

export default About;
