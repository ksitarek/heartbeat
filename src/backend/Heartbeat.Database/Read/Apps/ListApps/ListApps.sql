SELECT a."id"                           AS app_id,
       a."label"                        AS app_label,

       lc."status"                      AS last_check_status,
       lc."created_at"                  AS last_check_time,

       lv."was_verification_successful" AS last_verification_success,
       lv."created_at"                  AS last_verification_time

FROM "app" a

         JOIN LATERAL (
    SELECT c."label" AS check_label,
           csl."status",
           csl."created_at"
    FROM "check" c
             JOIN "check_status_log" csl ON c."id" = csl."check_id"
    WHERE c."app_id" = a."id"
    ORDER BY csl."created_at" DESC
    LIMIT 1
    ) lc ON TRUE

         JOIN LATERAL (
    SELECT "verification_strategy",
           "was_verification_successful",
           "created_at"
    FROM "verification_status"
    WHERE "app_id" = a."id"
    ORDER BY "created_at" DESC
    LIMIT 1
    ) lv ON TRUE