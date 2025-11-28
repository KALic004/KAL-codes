/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/UnitTests/JUnit5TestClass.java to edit this template
 */
package loginmodule;

import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class PayrollCalculatorTest {
    
    PayrollCalculator payrollCalculator = new PayrollCalculator();

	@Test
	public void testGetTotalSalary1() {
		double result = payrollCalculator.getTotalSalary(50, 5, 100);
		assertEquals(7750.0, result, 0.00001);
	}
	@Test
	public void testGetTotalSalary2() {
		double result = payrollCalculator.getTotalSalary(65.75, 5.5, 100.25);
		assertEquals(10248.78125, result, 0.00001);
	}
	@Test
	public void testGetTotalSalary3() {
		double result = payrollCalculator.getTotalSalary(100, 10.5, 300.2);
		assertEquals(46080.0, result, 0.00001);
	}
	@Test
	public void testGetRegularPay1() {
		payrollCalculator.getTotalSalary(200, 8, 2);
		double result = payrollCalculator.getRegularPay();
		assertEquals(1600.0, result, 0.00001);
	}
	@Test
	public void testGetRegularPay2() {
		payrollCalculator.getTotalSalary(300.5, 9.25, 2000);
		double result = payrollCalculator.getRegularPay();
		assertEquals(2779.625, result, 0.00001);
	}
	@Test
	public void testGetOverTimePay1() {
		payrollCalculator.getTotalSalary(200, 8, 2);
		double result = payrollCalculator.getOverTimePay();
		assertEquals(600.0, result, 0.00001);
	}
	@Test
	public void testGetOverTimePay2() {
		payrollCalculator.getTotalSalary(300.5, 9.25, 2000);
		double result = payrollCalculator.getOverTimePay();
		assertEquals(901500.0, result, 0.00001);
	}
    
}
