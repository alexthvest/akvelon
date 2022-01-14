import "@testing-library/jest-dom";

import React from "react";
import { App } from "../src/App";
import { render, screen } from "@testing-library/react";

test("renders learn react link", () => {
  render(<App />);

  const link = screen.getByText(/learn react/i);
  const linkHref = link.getAttribute("href");

  // Assert
  expect(link).toBeInTheDocument();
  expect(linkHref).toBe("https://reactjs.org");
});
