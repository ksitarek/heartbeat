SELECT
    "vs"."id" as "Id",
    "vc"."app_id" as "AppId",
    "vc"."id" as "VerificationConfigurationId",
    "vs"."created_at" as "CreatedAt",
    "vs"."verification_token" as "VerificationToken",
    "vs"."was_verification_successful" as "WasVerificationSuccessful",
    "vs"."last_verification_date_time" as "LastVerificationDateTime"
FROM "verification_status" as "vs"
INNER JOIN "verification_configuration" as "vc" ON "vc"."id" = "vs"."verification_configuration_id"
WHERE "vc"."app_id" = @AppId