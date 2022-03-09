import React from 'react';
import '@testing-library/jest-dom/extend-expect';
import { render , screen, fireEvent} from '@testing-library/react';
import Employee from './employee';

test('renders employee component', () => {
  const { getByText } = render(<Employee />);
  const employeeTable = getByText('Employee');
  expect(employeeTable).toBeInTheDocument();
});

test('shows add option for data row', () => {
  const { container } = render(<Employee />)  
  const linkAddButton = container.querySelector('.add-employee')  
  expect(linkAddButton).toBeInTheDocument();
});

test('shows search option for the table', () => {
  const { container } = render(<Employee />)  
  const linkSearchButton=screen.getByLabelText('Search')
  expect(linkSearchButton).toBeInTheDocument();
});

test('shows pagination option for the table', () => {
  const { container } = render(<Employee />)  
  const pagination = container.querySelector('.MuiTablePagination-selectIcon')
  const linkSearchButton=screen.getByLabelText('Rows per page:')
  const firstPage=container.querySelector('.first-page')
  const nextPage=container.querySelector('.next-page')
  const previousPage=container.querySelector('.previous-page')
  const lastPage=container.querySelector('.last-page')
  expect(linkSearchButton).toBeInTheDocument();
  expect(pagination).toBeInTheDocument();
  expect(nextPage).toBeInTheDocument();
  expect(lastPage).toBeInTheDocument();
  expect(firstPage).toBeInTheDocument();
  expect(previousPage).toBeInTheDocument();
});

test('shows edit option for data row', () => {
  const { container } = render(<Employee />)  
  const linkSearchButton=screen.getByLabelText('Rows per page:')
  expect(linkSearchButton).toBeInTheDocument();
});