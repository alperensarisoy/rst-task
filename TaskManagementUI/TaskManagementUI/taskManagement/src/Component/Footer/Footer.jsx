import React from "react";
import { Box, Typography, Link, IconButton, Container } from "@mui/material";
import { Facebook, Twitter, Instagram, LinkedIn } from "@mui/icons-material";

const Footer = () => {
  return (
    <Box
      sx={{
        bgcolor: "primary.main",
        color: "white",
        py: 4,
        mt: 4,
      }}
    >
      <Container maxWidth="lg">
        {/* Footer Links */}
        <Box
          sx={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            flexDirection: { xs: "column", sm: "row" },
          }}
        >
          {/* Logo or Title */}
          <Typography variant="h6" sx={{ mb: { xs: 2, sm: 0 } }}>
            My Application
          </Typography>

          {/* Navigation Links */}
          <Box
            sx={{
              display: "flex",
              gap: 2,
            }}
          >
            <Link href="/" color="inherit" underline="hover">
              Home
            </Link>
            <Link href="/about" color="inherit" underline="hover">
              About
            </Link>
            <Link href="/contact" color="inherit" underline="hover">
              Contact
            </Link>
          </Box>

          {/* Social Media Links */}
          <Box>
            <IconButton color="inherit" href="https://facebook.com">
              <Facebook />
            </IconButton>
            <IconButton color="inherit" href="https://twitter.com">
              <Twitter />
            </IconButton>
            <IconButton color="inherit" href="https://instagram.com">
              <Instagram />
            </IconButton>
            <IconButton color="inherit" href="https://linkedin.com">
              <LinkedIn />
            </IconButton>
          </Box>
        </Box>

        {/* Copyright Section */}
        <Typography variant="body2" sx={{ textAlign: "center", mt: 4 }}>
          &copy; {new Date().getFullYear()} My Application. All rights reserved.
        </Typography>
      </Container>
    </Box>
  );
};

export default Footer;
