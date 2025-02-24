import React from 'react';
import { Navbar, Nav, Container } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Navigation = () => (
  <Navbar bg="dark" variant="dark" expand="lg">
    <Container>
      <Navbar.Brand as={Link} to="/">Anagrafica Medica</Navbar.Brand>
      <Nav className="me-auto">
        <Nav.Link as={Link} to="/patients">Pazienti</Nav.Link>
        <Nav.Link as={Link} to="/doctors">Dottori</Nav.Link>
      </Nav>
    </Container>
  </Navbar>
);

export default Navigation;
