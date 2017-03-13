CREATE VIEW 选课人数
AS
SELECT 课程.课程号,课程名,课程.教师号,姓名,院系,COUNT(选课.课程号）AS 选课人数
FROM 选课 RIGHT JOIN 课程 ON 选课.课程号=课程.课程号
      FULL JOIN 教师 ON 课程.教师号=教师.教师号
GROUP BY dbo.课程.课程号,课程名,课程.教师号,姓名,院系