SELECT
    "vs"."id" as "Id",
    "vs"."app_id" as "AppId",
    "vs"."created_at" as "CreatedAt",
    "vs"."verification_token" as "VerificationToken",
    "vs"."was_verification_successful" as "WasVerificationSuccessful",
    "vs"."last_verification_date_time" as "LastVerificationDateTime"
FROM "verification_status" as "vs"
WHERE "vs"."app_id" = @AppId