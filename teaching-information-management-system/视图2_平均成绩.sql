CREATE VIEW 平均成绩
AS
SELECT 课程.课程号,课程名,课程.教师号,姓名,院系,AVG(选课.成绩) AS 平均成绩
FROM 选课 JOIN 课程 ON 选课.课程号 = 课程.课程号
          JOIN 教师 ON 课程.教师号 = 教师.教师号
GROUP BY 课程.课程号,课程名,课程.教师号,姓名,院系 