import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar, Nav } from 'react-bootstrap';

const Navigation = () => {
  return (
    <Navbar bg="light" expand="lg">
      <Navbar.Brand as={Link} to="/">Anagrafica Medica</Navbar.Brand>
      <Nav className="ml-auto">
        <Nav.Link as={Link} to="/patients">Pazienti</Nav.Link>
        <Nav.Link as={Link} to="/doctors">Dottori</Nav.Link>
        <Nav.Link as={Link} to="/healthcare-facilities">Strutture Sanitarie</Nav.Link> {/* Nuovo link */}
      </Nav>
    </Navbar>
  );
};

export default Navigation;
