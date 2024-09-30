-- SQL script 15 
-- 15.	Создайте профиль безопасности.

CREATE PROFILE profilename limit
password_life_time 180
sessions_per_user 3
FAILED_LOGIN_ATTEMPTS 7
PASSWORD_LOCK_TIME 1
PASSWORD_REUSE_TIME 10
PASSWORD_GRACE_TIME default
connect_time 180
idle_time 30;