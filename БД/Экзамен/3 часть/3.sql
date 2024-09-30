-- SQL script 3 
-- 3.	—оздайте процедуру, котора€ выводит в консоль список всех товаров, не приобретенных ни одним покупателем в определенном году по убыванию количества на складе. ѕараметр Ц год. ќбработайте возможные ошибки.

CREATE OR REPLACE PROCEDURE GetUnorderedProductsInYear(
    p_year NUMBER
)
IS
BEGIN
    FOR product_record IN (
        SELECT p.DESCRIPTION, p.QTY_ON_HAND
        FROM PRODUCTS p
        WHERE NOT EXISTS (
            SELECT 1
            FROM ORDERS o
            WHERE o.MFR = p.MFR_ID
              AND o.PRODUCT = p.PRODUCT_ID
              AND EXTRACT(YEAR FROM o.ORDER_DATE) = p_year
        )
        ORDER BY p.QTY_ON_HAND DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE('Product: ' || product_record.DESCRIPTION || ', Quantity on Hand: ' || product_record.QTY_ON_HAND);
    END LOOP;

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
END GetUnorderedProductsInYear;
/



EXEC GetUnorderedProductsInYear(2008);
